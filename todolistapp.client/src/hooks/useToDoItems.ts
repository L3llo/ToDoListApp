import { useState, useEffect } from "react";
import type { CreateToDoItemRequest, ToDoItem, UpdateToDoItemRequest } from "../types/toDoItem";
import { getAll, create, update, remove } from "../services/toDoItemService";

function useToDoItems() {
    const [toDoItems, setToDoItems] = useState<ToDoItem[]>([]);
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const [error, setError] = useState<Error | null>(null);

    async function withLoadingAndError(operation: () => Promise<void>) {
        setIsLoading(true);
        try {
            await operation();
        } catch (err) {
            if (err instanceof Error) setError(err);
        }
        setIsLoading(false);
    }

    useEffect(() => {
        withLoadingAndError(async () => {
            setToDoItems(await getAll());
        });
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

    return { toDoItems, isLoading, error, handleCreate, handleUpdate, handleRemove };
}

export { useToDoItems };
