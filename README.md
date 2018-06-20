# ***Maze Game***
Windows Forms Project by:
Nikola Krstevski
Vasko Jovanovski
Kristina Petrusevska 151504

## 1.Опис на апликацијата 
Tемата на проектот кој го изработивме е апликација за играта ** Maze Game ** - игра со движење на маусот кон целта-Finish. Целта на играта е да не ги допреме препреките со курсорот за да стигнеме до целта.
Играта покрај едноставниот дизајн, има и опција за рангирање и зачувување на најдобрите играчи. 
## 2.Упатство за користење
На почетниот прозорец, имаме опција за започнување на играта со кликање на Start.


![image](https://user-images.githubusercontent.com/28963796/41665719-ef7d8d30-74a8-11e8-83f5-8185b90fac10.png)
По кликање на копчето за почеток на играта, играта започнува. Играчот има дозволени 100 поени приажани исто така во вид на прогрес бар. на Секое ударање во препреките, играчот губи 20 поени. На тајминг од 5 секунди, играчот добива по пет поени. Тие информации играчот може да ги следи во Event log-от.
Исто така, прикажано е колку време играчот ја игра играта како и колку пати удрил во препреките.
Дозволени се и опции за зачувувањ на играта, паузирање, стопирање, нова игра и отворање на претходно сочувана игра.




![image](https://user-images.githubusercontent.com/28963796/41665796-2a052b16-74a9-11e8-9561-307fb950d3a9.png)


По истрошувањето на сите поени, на играчот му се отвора нов прозорец кој го известува дека играта е завршена и го прашува дали сака да да започне нова игра.


![image](https://user-images.githubusercontent.com/28963796/41665769-147a2a9e-74a9-11e8-8de3-f8ef3320b404.png)

Со кликање на копчето View/Save Players, на играчот му се отвара нова форма каде што може да го внесе играчот кој ја играл последната игра и да го зачува,при што подоле во листата ќе биде рангиран според другите играчи.

![image](https://user-images.githubusercontent.com/28963796/41665754-047ec4b0-74a9-11e8-97a7-edd1ab48c864.png)

Исто така, може да се сменат боите на позадината или на препреките, со што се добива подобар визуелен ефект.


![image](https://user-images.githubusercontent.com/28963796/41665778-1e7ba3c4-74a9-11e8-88c9-7724402c9cf7.png)


## 3. Претставување на проблемот
 
### 3.1 Податочни структури
За играта се направени 2 форми од кои едната е почетна форма, а другата е за рангот на играчите.
 
Form1 e почетната форма што ни се отвара со вклучување на играта :
```c#
namespace MazeGame
{

    public partial class Form1 : Form
    {
        Stopwatch stopwatch;
        Game igra;
        string filename = "";
        bool startedgame;
        bool paused;
        bool hitblock;
        string status;
        public string pom1;
        public string pom2;
        public Form1()
        {
            InitializeComponent();
            RefreshInfoTimer.Interval = 1000;
            stopwatch = new Stopwatch();
            igra = new Game();
            paused = false;
            status = "Stopped..";
            startedgame = false;
            progressBar1.Value = 100;
        } // initialization na promenlivi
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.K && startedgame) { StopGame(); } // P e za STOP
            else if (e.KeyCode == Keys.R) { StartGame(); }     // R e za Restart
            else if (e.KeyCode == Keys.S && startedgame) { saveGameDialog(); } // S e za SAVE
            else if (e.KeyCode == Keys.O) { openGameDialog(); } // O e za open
            else if (e.KeyCode == Keys.P && startedgame) { PauseGame(); } // K e za PauseGame

 
```
### 3.1.1. Finish label

```c#
        private void Finish_MouseEnter(object sender, EventArgs e)
        {

           if( MessageBox.Show("Congratiolations you have finished the game in " + igra.getTimespan(stopwatch).ToString("mm\\:ss") + " and you have hit the blocks only " + igra.hits.ToString() + " times. Do you want to save your score?","Save ?",MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                loadData();
                var form = new Form2();
                form.ShowDialog();
            }
            
            StopGame();
            
        } 

```

### 3.2 Алгоритми
 
За да биде целосна играта на меморија имплементиравме различни алгоритми за генерирање и валидирање на успешно решение.

