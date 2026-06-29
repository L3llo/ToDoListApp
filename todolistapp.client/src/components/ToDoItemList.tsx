import type { ToDoItem } from "../types/toDoItem";
import { ToDoSingleItem } from "./ToDoItem";

interface ToDoItemListProps {
    items: ToDoItem[];
    onToggle: (id: number) => void;
    onEdit: (item: ToDoItem) => void;
    onDelete: (id: number) => void;
}

function ToDoItemList({ items, onToggle, onEdit, onDelete }: ToDoItemListProps) {
    if (items.length === 0) {
        return <p className="todo-list__empty">Nessuna attività. Creane una!</p>;
    }

    return (
        <div className="todo-list">
            {items.map(item => (
                <ToDoSingleItem
                    key={item.id}
                    item={item}
                    onToggle={onToggle}
                    onEdit={onEdit}
                    onDelete={onDelete}
                />
            ))}
        </div>
    );
}

export { ToDoItemList };
