# 🚗 Autosaloni - Gestione Database

## 📌 Configurazione del Database

Per eseguire correttamente il progetto, segui questi passaggi:

1. **Imposta la variabile d'ambiente `DB_CONNECTION_STRING`** con la tua stringa di connessione.

   - **Metodo Grafico (Windows)**:
     1. Premi `Win + R`, digita `sysdm.cpl` e premi **Invio**.
     2. Vai alla scheda **Avanzate** → clicca su **Variabili d'ambiente**.
     3. Nella sezione **Variabili di sistema**, clicca su **Nuovo**.
     4. **Nome variabile**: `DB_CONNECTION_STRING`
     5. **Valore variabile**: `Data Source=IL_TUO_SERVER\SQLEXPRESS;Initial Catalog=AUTOSALONI;Integrated Security=True;Encrypt=False`
     6. Clicca **OK**, poi **Applica**.
     7. Riavvia il PC per applicare le modifiche.
   - **Su Windows (CMD)**:
     ```sh
     setx DB_CONNECTION_STRING "Data Source=IL_TUO_SERVER\SQLEXPRESS;Initial Catalog=AUTOSALONI;Integrated Security=True;Encrypt=False"
     ```
   - **Su PowerShell**:
     ```sh
     [System.Environment]::SetEnvironmentVariable("DB_CONNECTION_STRING", "Data Source=IL_TUO_SERVER\SQLEXPRESS;Initial Catalog=AUTOSALONI;Integrated Security=True;Encrypt=False", "User")
     ```
   - **Su Linux/macOS (Bash)**:
     ```sh
     export DB_CONNECTION_STRING="Data Source=IL_TUO_SERVER\SQLEXPRESS;Initial Catalog=AUTOSALONI;Integrated Security=True;Encrypt=False"
     ```

   Dopo aver impostato la variabile, **riavvia il computer o il terminale** per renderla effettiva.

2. **Verifica che la variabile sia stata impostata correttamente:**

   - Su **CMD**:
     ```sh
     echo %DB_CONNECTION_STRING%
     ```
   - Su **PowerShell**:
     ```sh
     Get-ChildItem Env:DB_CONNECTION_STRING
     ```
   - Su **Linux/macOS**:
     ```sh
     echo $DB_CONNECTION_STRING
     ```

---

## 🛠️ Dipendenze NuGet

Dopo aver clonato il repository, esegui il seguente comando per reinstallare i pacchetti NuGet mancanti:  
Strumenti > Gestione pacchetti NuGet > Console di gestione pacchetti

```sh
Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -reinstall
