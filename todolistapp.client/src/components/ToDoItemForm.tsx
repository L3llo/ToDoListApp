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
        <div className="modal-overlay" onClick={onClose}>
            <div className="modal" onClick={e => e.stopPropagation()}>
                <h2>{item ? 'Modifica attività' : 'Nuova attività'}</h2>

                <input
                    className="form-input"
                    type="text"
                    value={title}
                    onChange={e => setTitle(e.target.value)}
                    placeholder="Titolo"
                    maxLength={200}
                />

                <textarea
                    className="form-textarea"
                    value={description}
                    onChange={e => setDescription(e.target.value)}
                    placeholder="Descrizione (opzionale)"
                    maxLength={1000}
                />

                <div className="modal__actions">
                    <button className="btn btn--primary" onClick={handleSubmit}>Salva</button>
                    <button className="btn" onClick={onClose}>Annulla</button>
                </div>
            </div>
        </div>
    );
}

export { ToDoItemForm };
