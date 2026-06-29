import { useState } from "react";
import type { ToDoItem } from "../types/toDoItem";
import { FiEdit, FiTrash2, FiChevronDown, FiChevronUp } from "react-icons/fi";
interface ToDoItemProps {
    item: ToDoItem;
    onToggle: (id: number) => void;
    onEdit: (item: ToDoItem) => void;
    onDelete: (id: number) => void;
}

function ToDoSingleItem({ item, onToggle, onEdit, onDelete }: ToDoItemProps) {
    const [isExpanded, setIsExpanded] = useState<boolean>(false);

    return (
        <div>
            <span>{item.title}</span>
            <input
                type="checkbox"
                checked={item.state === 'Completed'}
                onChange={() => onToggle(item.id)}
            />
            <button onClick={() => onEdit(item)}><FiEdit /></button>
            <button onClick={() => onDelete(item.id)}><FiTrash2 /></button>
            {item.description && (
                <button onClick={() => setIsExpanded(!isExpanded)}>
                    {isExpanded ? <FiChevronUp /> : <FiChevronDown />}
                </button>
            )}
            {isExpanded && <p>{item.description}</p>}
        </div>
    );
}   

export { ToDoSingleItem }