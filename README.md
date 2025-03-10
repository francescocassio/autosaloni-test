# 🚗 Autosaloni - Gestione Database

## 📌 Configurazione del Database

Per eseguire correttamente il progetto, segui questi passaggi:

1. **Copia il file di esempio della configurazione:**  
   Nella cartella `App_Code/`, c'è un file chiamato **`DBConfigExample.cs`**. Creane una copia e salvala come **`DBConfig.cs`**.

2. **Modifica `DBConfig.cs` con la classe DBConfig invece di DBConfigExample e usa i tuoi parametri di connessione:**  
   Apri il file e personalizza questa stringa di connessione con il tuo server SQL:
   ```csharp
   public DBConfig()
   {
       connectionString = "Data Source=IL_TUO_SERVER\SQLEXPRESS;Initial Catalog=AUTOSALONI;Integrated Security=True;Encrypt=False";
   }
   ```

3. **Assicurati che `DBConfig.cs` non venga tracciato su Git:**  
   Questo file è già incluso nel `.gitignore`, quindi non verrà mai committato nel repository.

---

## 🛠️ Dipendenze NuGet

Dopo aver clonato il repository, esegui il seguente comando per reinstallare i pacchetti NuGet mancanti:  
Strumenti > Gestione pacchetti NUget > Console di gestione pacchetti
```sh
Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -reinstall
```

Se non hai NuGet installato, puoi eseguire il comando direttamente dalla **Package Manager Console** di Visual Studio.

---

## 🚀 Avvio del Progetto

1. **Assicurati di avere SQL Server in esecuzione** con il database `AUTOSALONI` configurato correttamente.
2. **Modifica `DBConfig.cs`** con i tuoi parametri di connessione.
3. **Esegui il comando NuGet sopra indicato per sistemare le dipendenze.**
4. **Avvia l'applicazione da Visual Studio.**

Ora il tuo progetto è pronto! 🎉
