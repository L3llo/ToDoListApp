import { useState } from "react";
import type { ToDoItem, ToDoItemFormData } from "../types/toDoItem";

interface ToDoItemFormProps {
    item: ToDoItem | null;
    onSave: (data: ToDoItemFormData) => void;
    onClose: () => void;
}

function ToDoItemForm({ item, onSave, onClose }: ToDoItemFormProps) {
    const [title, setTitle] = useState<string>(item?.title ?? '');
    const [description, setDescription] = useState<string>(item?.description ?? '');

    function handleSubmit() {
        const data: ToDoItemFormData = { title, description };
        onSave(data);
        onClose();
    }

    return (
        <div>
            <h2>{item ? 'Modifica attività' : 'Nuova attività'}</h2>

            <input
                type="text"
                value={title}
                onChange={e => setTitle(e.target.value)}
                placeholder="Titolo"
            />

            <textarea
                value={description}
                onChange={e => setDescription(e.target.value)}
                placeholder="Descrizione (opzionale)"
            />

            <button onClick={handleSubmit}>Salva</button>
            <button onClick={onClose}>Annulla</button>
        </div>
    );
}

export { ToDoItemForm };
