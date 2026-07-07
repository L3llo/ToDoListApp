import { useState, useEffect } from "react";
import axios from "axios";
import type { CreateToDoItemRequest, ToDoItem, UpdateToDoItemRequest } from "../types/toDoItem";
import { getAll, create, update, remove } from "../services/toDoItemService";

function toFriendlyError(err: unknown): Error {
    // 503 here is the backend's GlobalExceptionHandler mapping RetryLimitExceededException
    // to a transient error during the Azure SQL free-tier cold start.
    if (axios.isAxiosError(err) && err.response?.status === 503) {
        return new Error("Il server si sta riattivando dopo un periodo di inattività: riprova tra qualche secondo.");
    }
    return err instanceof Error ? err : new Error("Si è verificato un errore imprevisto.");
}

function useToDoItems() {
    const [toDoItems, setToDoItems] = useState<ToDoItem[]>([]);
    // True solo durante il primo caricamento (soggetto al cold start del DB); le azioni CRUD usano isLoading.
    const [isInitialLoading, setIsInitialLoading] = useState<boolean>(true);
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const [error, setError] = useState<Error | null>(null);

    async function withLoadingAndError(operation: () => Promise<void>) {
        setIsLoading(true);
        try {
            await operation();
            setError(null);
        } catch (err) {
            setError(toFriendlyError(err));
        }
        setIsLoading(false);
    }

    useEffect(() => {
        withLoadingAndError(async () => {
            setToDoItems(await getAll());
        }).finally(() => setIsInitialLoading(false));
    }, []);

    async function handleCreate(item: CreateToDoItemRequest) {
        await withLoadingAndError(async () => {
            const newItem = await create(item);
            setToDoItems([...toDoItems, newItem]);
        });
    }

    async function handleUpdate(id: number, item: UpdateToDoItemRequest) {
        await withLoadingAndError(async () => {
            const updatedItem = await update(id, item);
            setToDoItems(toDoItems.map(t => t.id === updatedItem.id ? updatedItem : t));
        });
    }

    async function handleRemove(id: number) {
        await withLoadingAndError(async () => {
            await remove(id);
            setToDoItems(toDoItems.filter(t => t.id !== id));
        });
    }

    return { toDoItems, isInitialLoading, isLoading, error, handleCreate, handleUpdate, handleRemove };
}

export { useToDoItems };
