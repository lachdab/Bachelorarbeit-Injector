# Dll Injector für meine Bachelorarbeit
## Der Injector verwendet die bekannteste injection Methode (CreateRemoteThread und LoadLibaryA aus der kernel32.dll)

# Wie funktioniert der Injector?
1. Er holt sich den handle von unserem Spiel
2. Mit GetProcAdress() kriegen wir die Addresse von der LoadLibraryA() Methode (aus kernel32.dll)
3. Mit VirutalAllocEx() weisen wir memory zu unserem Spiel hinzu
4. Mit WriteProcessMemory() schreiben wir unseren Pfad von der Cheat dll hinein
5. Mit CreateRemoteThread() erstellen wir einen thread der LoadLibraryA() aufruft mit pointer zu unserer zugewiesen Addresse wo unsere Cheat dll ist


> [!NOTE]
> dies funktioniert gut aber nur weil im Moment kein Anti-Cheat im Spiel ist
