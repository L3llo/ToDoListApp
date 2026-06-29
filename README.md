# ToDoListApp

## Architettura scelta
Per l'architettura dell'applicazione mi sono affidato all'utilizzo delle tecnologie indicate nella consegna, in modo da poter ottimizzare il tempo a mia disposizione per lo sviluppo del progetto.

### Backend
il progetto di backend è strutturato secondo i principi della clean architecture, ma in una versione semplificata: al posto che avere 4-5 progetti diversi che descrivono i vari layer del modello, ho pensato di traslare questo compito tramite l'utilizzo di cartelle. Questa scelta deriva dalla bassa complessità operativa dell'applicazione, e ho preferito evitare la creazione di molteplici progetti praticamente vuoti. La struttura a cartelle, per come si presenta, è facilmente convertibile in un modello clean architecture classico: è sufficiente prendere le cartelle e trasformarle in progetti a se stanti e aggiungere le dipendenze necessarie e i riferimenti tra progetti. I modelli dei dati provenienti dal database vengono gestiti tramite Entity Framework Core, che tramite un approccio code-first mi ha permesso di definire prima i modelli in C#, per poi andare a traslarli sia sul db locale (utilizzato in fase di testing inziale per non sprecare i limiti di utilizzo di Azure) che sul db instanziato su Azure.

### Frontend
il progetto di backend è strutturato secondo lo schema architetturale Model-View-ViewModel. Ho deciso di utilizzare typescript in quanto l'implementazione del type-safe lo rende più in linea con il backend C# rispetto a Javascript tradizionale in cui non ci sono vincoli di tipo. L'applicazione implementa una semplice interfaccia che permette di effettuare le operazioni CRUD. Essendo che non era richiesta una grafica avanzata mi sono limitato a rendere ben impaginato il contenuto, preoccupandomi di garantire una corretta leggiblità anche nel caso di utilizzo da dispositivi mobile.

## Risorse Azure utilizzate

### Persistenza dei dati
(inserire informazioni su soluzione azure utilizzata per gestire la persistenza)

### Hosting frontend
### Hosting backend
### Alternative considerate

## Organizzazione del repository
l'applicazione è stata creata a partire dal template di visual studio "React e ASP.NET Core (Typescript)". Il template prevede la creazione di due progetti distinti, uno dedicato al backend e l'altro dedicato al frontend. (Aggiungere eventualmente sviluppo futuri su questa questione)

## Funzionamento della pipeline
## Limiti noti
## Possibili evoluzioni future



