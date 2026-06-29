import axios from "axios";
import type { CreateToDoItemRequest, ToDoItem, UpdateToDoItemRequest } from "../types/toDoItem";

const apiClient = axios.create({
    baseURL: '/api'
});

async function getAll() : Promise<ToDoItem[]> {
    var response = await apiClient.get<ToDoItem[]>('/ToDoItems');
    return response.data;
}

async function getById(id: number) : Promise<ToDoItem> {
    var response = await apiClient.get<ToDoItem>(`/ToDoItems/${id}`)
    return response.data;
}

async function create(item: CreateToDoItemRequest): Promise<ToDoItem> {
    var response = await apiClient.post<ToDoItem>('/ToDoItems', item);
    return response.data;
}

async function update(id: number, item: UpdateToDoItemRequest) : Promise<ToDoItem> {
    var response = await apiClient.put<ToDoItem>(`/ToDoItems/${id}`, item);
    return response.data;
}

async function remove (id: number) : Promise<void> {
    await apiClient.delete(`/ToDoItems/${ id }`);
}

export { getAll, getById, create, update, remove };