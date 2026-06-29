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

    function handleDelete(e: React.MouseEvent) {
        e.stopPropagation();
        if (confirm(`Eliminare "${item.title}"?`)) onDelete(item.id);
    }

    return (
        <div className={`todo-item ${item.state === 'Completed' ? 'todo-item--completed' : ''}`}>
            <div className="todo-item__row">
                <input
                    type="checkbox"
                    checked={item.state === 'Completed'}
                    onChange={() => onToggle(item.id)}
                    onClick={e => e.stopPropagation()}
                />
                <span className="todo-item__title">{item.title}</span>
                <div className="todo-item__actions">
                    {item.description && (
                        <button className="btn-icon" onClick={() => setIsExpanded(!isExpanded)}>
                            {isExpanded ? <FiChevronUp /> : <FiChevronDown />}
                        </button>
                    )}
                    <button className="btn-icon" onClick={e => { e.stopPropagation(); onEdit(item); }}><FiEdit /></button>
                    <button className="btn-icon btn-icon--danger" onClick={handleDelete}><FiTrash2 /></button>
                </div>
            </div>
            {isExpanded && <p className="todo-item__description">{item.description}</p>}
        </div>
    );
}

export { ToDoSingleItem };
