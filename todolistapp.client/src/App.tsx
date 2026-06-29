import { useState } from 'react';
import { useToDoItems } from './hooks/useToDoItems';
import { ToDoItemList } from './components/ToDoItemList';
import { ToDoItemForm } from './components/ToDoItemForm';
import type { ToDoItem, ToDoItemFormData } from './types/toDoItem';
import './App.css';

function App() {
    const { toDoItems, isLoading, error, handleCreate, handleUpdate, handleRemove } = useToDoItems();
    const [selectedItem, setSelectedItem] = useState<ToDoItem | null | undefined>(undefined);

    async function handleSave(data: ToDoItemFormData) {
        if (selectedItem === null) {
            await handleCreate(data);
        } else if (selectedItem !== undefined) {
            await handleUpdate(selectedItem.id, { ...data, state: selectedItem.state });
        }
        setSelectedItem(undefined);
    }

    function handleToggle(id: number) {
        const item = toDoItems.find(t => t.id === id);
        if (item) handleUpdate(id, {
            title: item.title,
            description: item.description,
            state: item.state === 'Open' ? 'Completed' : 'Open'
        });
    }

    return (
        <div className="app">
            <div className="app__header">
                <h1>ToDo App</h1>
                <button className="btn btn--primary" onClick={() => setSelectedItem(null)}>+ Nuova attività</button>
            </div>

            {isLoading && <p>Caricamento...</p>}
            {error && <p>Errore: {error.message}</p>}

            <ToDoItemList
                items={toDoItems}
                onToggle={handleToggle}
                onEdit={item => setSelectedItem(item)}
                onDelete={handleRemove}
            />

            {selectedItem !== undefined && (
                <ToDoItemForm
                    item={selectedItem}
                    onSave={handleSave}
                    onClose={() => setSelectedItem(undefined)}
                />
            )}
        </div>
    );
}

export default App;
