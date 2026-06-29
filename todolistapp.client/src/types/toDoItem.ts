export type ToDoItemState = 'Open' | 'Completed';  

export interface ToDoItemFormData {
    title: string;
    description?: string;
}

export interface ToDoItem {
    id: number;
    title: string;
    description?: string;
    state: ToDoItemState;
    createdAt: string;
    completedAt?: string;
}

export interface CreateToDoItemRequest extends ToDoItemFormData {
}

export interface UpdateToDoItemRequest extends ToDoItemFormData {
    state: ToDoItemState;
}