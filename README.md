# la-mia-pizzeria-crud-mvc
IMPORTANTE: Ricordatevi di sganciare la vostra vecchia repository GIT e di crearne una nuova per questo esercizio, che prosegue il lavoro della pizzeria, dove lo avevate lasciato. Potete eliminare il progetto Razor da questa esercitazione.

Ciao ragazzi,
andiamo avanti con l’applicazione per gestire la nostra pizzeria.

Lo scopo di oggi è quello di rendere dinamici i contenuti che abbiamo come html statico nella pagina con la lista delle pizze.

Creiamo prima un nostro controller chiamato PizzaController e utilizziamo lui d’ora in avanti.

L’elenco delle pizze ora va passato come model dal controller, e la view deve utilizzarlo per mostrare l’html corretto.

Gestiamo anche la possibilità che non ci siano pizze nell’elenco: in quel caso dobbiamo mostrare un messaggio che indichi all’utente che non ci sono pizze presenti nella nostra applicazione.

Ogni pizza dell’elenco avrà un pulsante che se cliccato ci porterà a una pagina che mostrerà i dettagli di quella singola pizza.

Dobbiamo quindi inviare l’id come parametro dell’URL, recuperarlo con la action, caricare i dati della pizza ricercata e passarli come model.

La view a quel punto li mostrerà all’utente con la grafica che preferiamo.

Ps. visto che abbiamo cambiato il controller sul quale lavoriamo, ricordiamoci di cambiare anche il “mapping di default” dei controller...altrimenti quale pagina viene caricata se richiamo l’url “/” della nostra webapp?

Piccolo dettaglio…ricordatevi che i dati delle pizze devono essere in un database…quindi dobbiamo usare Entity Framework! ;)
