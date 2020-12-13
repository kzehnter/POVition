# Funktional:

##### Muss-Kriterien

- Puzzlespiel mit 10 Levels
- Titelmenü + Levelauswahl als VR-Menü
- Support für Maus und Tastatur
- Bewegung erfolgt über VR-Teleport
- Spieler kann sich frei im Level bewegen und wird nur von Barrieren und Blöcken gestoppt
- Zentrales Spielelement: teleportierender Block
    * Spieler tauscht Position mit Block über Anvisierung mit Controller
    * besitzt Physik, ist gravitativ
- 3 zusätzliche Blockvariationen:
    * Zielblock
        * muss berührt werden für Levelabschluss
    * Timer
        * nach erstem Teleport läuft eine Zeit ab
        * danach tauschen Spieler und Block erneut die Positionen ohne direktes Interagieren
    * Countdown
        * Ist mit einer Zahl n beschriftet
        * kann exakt n-mal teleportiert werden, die Beschriftung wird bei jedem Teleport mit angepasst
        * bei n<1 zerstört sich der Block

##### Soll-Kriterien

- Verketteter Block
    * ist verbunden mit mindestens einem weiteren Block
    * Bei Teleport mit einem Block der Kette wird der Spieler direkt anschließend mit dem nächsten Kettenblock getauscht
- Anti-Glas Block
    * kann nicht durch transparente Barrieren anvisiert werden
- Hebel, Knöpfe als weitere Möglichkeit neben Druckplatten für Aktionsauslösung
- Konkrete Texturen, Modelle und Leuchteffekte für Spielelemente