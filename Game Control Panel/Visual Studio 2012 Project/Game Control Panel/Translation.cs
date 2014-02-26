using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;//For writing debug messages

namespace Game_Control_Panel
{
    class Translation
    {
        public enum LANGUAGES
        {
            English = 0,
            Chinese = 1
            //If additional lanugages are added the NUMBEROFLANGUAGES constant should be changed and the dictonary should be updated
            //When adding new languages check for substrings that could cause errors when replacing values in the file in the ScoreControl.UpdateLanguage() function
        };
        private const byte NUMBEROFLANGUAGES = 2;
        public enum WORDS
        {
            File = 0,//for the File menu
            About = 1,//to open the About window (File/About)
            Languages = 2,//for the Languages menu
            English = 3,//for (Languages/English)
            Chinese = 4,//for (Languages/Chinese)
            Help = 5,//for the Help menu
            OpenHelpFile = 6,//for (Help/OpenHelpFile)
            ViewHelpWebsite = 7,//for (Help/ViewHelpFile)
            GameSettings = 8,//for the label that says Game Settings and the file header
            NumberOfLives = 9,//for the Number of Lives Label
            OneLife = 10,//for the Number of lives combo box
            TwoLives = 11,//for the Number of lives combo box
            ThreeLives = 12,//for the Number of lives combo box
            FourLives = 13,//for the Number of lives combo box
            FiveLives = 14,//for the Number of lives combo box
            SixLives = 15,//for the Number of lives combo box
            GameLength = 16,//for Game Length label
            OneMinute = 17,//for Game Length combo box
            TwoMinutes = 18,//for Game Length combo box
            ThreeMinutes = 19,//for Game Length combo box
            FourMinutes = 20,//for Game Length combo box
            FiveMinutes = 21,//for Game Length combo box
            SixMinutes = 22,//for Game Length combo box
            SevenMinutes = 23,//for Game Length combo box
            EightMinutes = 24,//for Game Length combo box
            NineMinutes = 25,//for Game Length combo box
            TenMinutes = 26,//for Game Length combo box
            FifteenMinutes = 27,//for Game Length combo box
            TwentyMinutes = 28,//for Game Length combo box
            TwentyFiveMinutes = 29,//for Game Length combo box
            ThirtyMinutes = 30,//for Game Length combo box
            ThirtyFiveMinutes = 31,//for Game Length combo box
            FourtyMinutes = 32,//for Game Length combo box
            FourtyFiveMinutes = 33,//for Game Length combo box
            FiftyMinutes = 34,//for Game Length combo box
            FiftyFiveMinutes = 35,//for Game Length combo box
            SixtyMinutes = 36,//for Game Length combo box
            IndividualGame = 37,//for the Individual Game radio button
            TeamGame = 38,//for the Team Game radio button
            Start = 39,//for the start button
            ResumeGame = 40,//for the start button when resuming a game in progress
            EmergencyStop = 41,//for the EStop button
            RestGame = 42,//for the EStop button to reset a game when the game is over
            TimeRemaining = 43,//for the Time Remaining label above the timer label
            GameScores = 44,//for the Game Scores label above the scores window
            Player1 = 45,//for the label Player1
            Player2 = 46,//for the label Player2
            Player3 = 47,//for the label Player3
            Player4 = 48,//for the label Player4 
            Team1 = 49,//for the label Player1
            Team2 = 50,//for the label Player2
            Team3 = 51,//for the label Player3
            Team4 = 52,//for the label Player4 
            NumberOfTeams = 53,//for the Number of Teams label
            TwoTeams = 54,//for the Number of Teams combo box
            ThreeTeams = 55,//for the Number of Teams combo box
            FourTeams = 56,//for the Number of Teams combo box
            GameControlPanel = 57,//for the title of the application
            Points = 58,//for displaying the number of points in the labels
            GameControlPanelVersion = 59,//for displaying the version number in the about window
            RobotagGame = 60,//for displaying in the file header
            GameStarted = 61,//for displaying in the file header
            STARTKEYWORD = 62,//for displaying foreign user friendly translation of the start keyword
            RESUMEKEYWORD = 63,//for displaying foreign user friendly translation of the resume keyword
            ENDKEYWORD = 64,//for displaying foreign user friendly translation of the end keyword
            ENDKEYWORDBecauseOnlyOnePlayerIsRemaining = 65,//for displaying foreign user friendy translation of the keyword with a description of why the game stopped
            Shot = 66,//for the output file to read PlayerX shot PlayerY
            FileNotFoundErrorMessage = 67,//for printing to the file if the file goes missing during the game
            NumberOfLivesComboBoxToolTip = 68,//for whent the user hovers their mouse over this control
            GameLengthComboBoxToolTip = 69,//for whent the user hovers their mouse over this control
            IndividualGameRadioButtonToolTip = 70,//for whent the user hovers their mouse over this control
            TeamGameRadioButtonToolTip = 71,//for whent the user hovers their mouse over this control
            NumberOfTeamsComboBoxToolTip = 72,//for whent the user hovers their mouse over this control
            StartButtonToolTip = 73,//for whent the user hovers their mouse over this control
            EStopButtonToolTip = 74,//for whent the user hovers their mouse over this control
            FileError = 75,//for the file error pop up box
            ErrorWritingToFile = 76,//for the file error pop up box
            ErrorReadingFromFile = 77,//for the file error pop up box
            FinalGameScores = 78//for appending to the end of the file after the game is reset
            //If additional words are added the NUMBEROFWORDS constant should be changed and the dictonary should be updated
        };
        private const byte NUMBEROFWORDS = 79;
        private static LANGUAGES Language; //Default language is English (LANGUAGES=0)
        private static LANGUAGES PreviousLanguage; //Used for replacing strings from the previous language
        private string[,] dictionary = {
            {"File", "文件"}, //File=0, for the File menu
            {"About", "关于"},//About=1, to open the About window (File/About)
            {"Languages","文"},//Languages=2, for the Languages menu
            {"English","English"},//English=3, for (Languages/English) kept as English in all languages to make it easier for natives to identify
            {"中文","中文"},//Chinese=4, for (Languages/中文) kept as 中文 in all languages to make it easier for natives to identify
            {"Help", "帮助"},//Help=5, for the Help menu
            {"Open Help File", "开始帮助文件"},//OpenHelpFile=6, for (Help/OpenHelpFile)
            {"View Help Website", "开始帮助网址"},//ViewHelpWebsite=7, for (Help/ViewHelpFile)
            {"Game Settings","游戏选项"},//GameSettings=8, for the label that says Game Settings
            {"Number of Lives", "几个生命"},//NumberOfLives=9, for the Number of Lives Label
            {"1 Life","一个生命"},//OneLife = 10, for the Number of lives combo box
            {"2 Lives","两个生命"},//TwoLives = 11, for the Number of lives combo box
            {"3 Lives","三个生命"},//ThreeLives = 12, for the Number of lives combo box
            {"4 Lives","四个生命"},//FourLives = 13, for the Number of lives combo box
            {"5 Lives","五个生命"},//FiveLives = 14, for the Number of lives combo box
            {"6 Lives","六个生命"},//SixLives = 15, for the Number of lives combo box
            {"Game Length","游戏长度"},//GameLength = 16, for Game Length label
            {"1 Minute","一个分钟"},//OneMinute = 17, for Game Length combo box
            {"2 Minutes","两个分钟"},//TwoMinutes = 18, for Game Length combo box
            {"3 Minutes","三个分钟"},//ThreeMinutes = 19, for Game Length combo box
            {"4 Minutes","四个分钟"},//FourMinutes = 20, for Game Length combo box
            {"5 Minutes","五个分钟"},//FiveMinutes = 21, for Game Length combo box
            {"6 Minutes","六个分钟"},//SixMinutes = 22, for Game Length combo box
            {"7 Minutes","七个分钟"},//SevenMinutes = 23, for Game Length combo box
            {"8 Minutes","八个分钟"},//EightMinutes = 24, for Game Length combo box
            {"9 Minutes","九个分钟"},//NineMinutes = 25, for Game Length combo box
            {"10 Minutes","十个分钟"},//TenMinutes = 26, for Game Length combo box
            {"15 Minutes","十五个分钟"},//FifteenMinutes = 27, for Game Length combo box
            {"20 Minutes","二十个分钟"},//TwentyMinutes = 28, for Game Length combo box
            {"25 Minutes","二十五个分钟"},//TwentyFiveMinutes = 29, for Game Length combo box
            {"30 Minutes","三十个分钟"},//ThirtyMinutes = 30, for Game Length combo box
            {"35 Minutes","三十五个分钟"},//ThirtyFiveMinutes = 31, for Game Length combo box
            {"40 Minutes","四十个分钟"},//FourtyMinutes = 32, for Game Length combo box
            {"45 Minutes","四十五个分钟"},//FourtyFiveMinutes = 33, for Game Length combo box
            {"50 Minutes","五十个分钟"},//FiftyMinutes = 34, for Game Length combo box
            {"55 Minutes","五十五个分钟"},//FiftyFiveyMinutes = 35, for Game Length combo box
            {"60 Minutes","六十个分钟"},//SixtyMinutes = 36, for Game Length combo box
            {"Individual Game","没队游戏"},//IndividualGame = 37, for the Individual Game radio button
            {"Team Game","队游戏"},//TeamGame = 38, for the Team Game radio button
            {"Start","开始"},//Start = 39, for the start button
            {"Resume Game","继续游戏"},//ResumeGame = 40, for the start button when resuming a game in progress
            {"Emergency Stop","安全停"},//EmergencyStop = 41, for the EStop button
            {"Reset Game","重新开始游戏"},//RestGame = 42, for the EStop button to reset a game when the game is over
            {"Time Remaining","时候里游戏"},//TimeRemaining = 43, for the Time Remaining label above the timer label
            {"Game Scores","游戏的得分"},//GameScores = 44, for the Game Scores label above the scores window
            {"Player 1","选手1"},//Player1 = 45, for the label Player1
            {"Player 2","选手2"},//Player2 = 46, for the label Player2
            {"Player 3","选手3"},//Player3 = 47, for the label Player3
            {"Player 4","选手4"},//Player4 = 48 for the label Player4 
            {"Team 1","队1"},//Team1 = 49, for the label Player1
            {"Team 2","队2"},//Team2 = 50, for the label Player2
            {"Team 3","队3"},//Team3 = 51, for the label Player3
            {"Team 4","队4"},//Team4 = 52, for the label Player4 
            {"Number of Teams","几个队"},//NumberOfTeams = 53, for the Number of Teams label
            {"2 Teams","两个队"},//TwoTeams = 54, for the Number of Teams combo box
            {"3 Teams","三个队"},//ThreeTeams = 55, for the Number of Teams combo box
            {"4 Teams","四个队"},//FourTeams = 56, for the Number of Teams combo box
            {"Game Control Panel","游戏控制台"},//GameControlPanel = 57 for the title of the application
            {"Points","得分"},//Points = 58. for displaying the number of points in the labels
            {"Game Control Panel Version","游戏控制台版本"},//GameControlPanelVersion = 59, for displaying the version number in the about window
            {"Robotag Game","机器人搏击游戏"},//RobotagGame = 60, for displaying in the file header
            {"Game Started","游戏开始了"},//GameStarted = 61, for displaying in the file header
            {UserInterface.STARTKEYWORD,"开始了游戏 "+UserInterface.STARTKEYWORD},//STARTKEYWORD = 62 for displaying foreign user friendly translation of the start keyword.
            //Keeps the constant untranslated so that the Game Server may still read the keyword.
            {UserInterface.RESUMEKEYWORD,"继续游戏 "+UserInterface.RESUMEKEYWORD},//RESUMEKEYWORD = 63, for displaying foreign user friendly translation of the resume keyword
            {UserInterface.ENDKEYWORD, "停游戏 "+UserInterface.ENDKEYWORD},//ENDKEYWORD = 64, for displaying foreign user friendly translation of the end keyword
            {UserInterface.ENDKEYWORD + " because only one player is remaining.", "停游戏因为就一个人不死了 " + UserInterface.ENDKEYWORD + " because only one player is remaining."},//ENDKEYWORDBecauseOnlyOnePlayerIsRemaining = 65,for displaying foreign user friendy translation of the keyword with a description of why the game stopped
            {" shot ","打了"},//shot = 66 for the output file to read PlayerX shot PlayerY
            {"Error: Score file was not found and was replaced by a new score file.","对不起：不可以找到游戏得分文件，所以开始新的游戏得分文件。"},//FileNotFoundErrorMessage = 67 for printing to the file if the file goes missing during the game
            {"This drop down allows the attraction host to specify the number of lives available for each player.",""},//NumberOfLivesComboBoxToolTip = 68, for whent the user hovers their mouse over this control
            {"This allows the attraction host to specify the length of the game.",""},//GameLengthComboBoxToolTip = 69, for whent the user hovers their mouse over this control
            {"This allows the attraction host to specify an individual game.",""},//IndividualGameRadioButtonToolTip = 70, for whent the user hovers their mouse over this control
            {"This allows the attraction host to specify a team game.",""},//TeamGameRadioButtonToolTip = 71, for whent the user hovers their mouse over this control
            {"This allows the attraction host to specify the number of teams.",""},//NumberOfTeamsComboBoxToolTip = 72, for whent the user hovers their mouse over this control
            {"This button will start or resume the gameplay.",""},//StartButtonToolTip = 73, for whent the user hovers their mouse over this control
            {"This button will stop an active the gameplay in the event of an emergency.\nIf the game has already been stopped this button can also be used to reset the game.\r\nThe text of the button will change to indicate if the button will stop or reset the game.",""},//EStopButtonToolTip = 74 for whent the user hovers their mouse over this control
            {"File Error", "文件问题"},//FileError = 75 for the file error pop up box
            {"Error Writing to File", "问题写在文件"},//ErrorWritingToFile = 76 for the file error pop up box
            {"Error Reading from File", "问题看在文件"},//ErrorReadingFromFile = 77 for the file error pop up box
            {"Final Game Scores:","完了游戏得分："}//FinalGameScores = 78 for appending to the end of the file after the game is reset
                                        };
        public Translation()
        {
        }

        public string GetWord(WORDS word)
        {
            if ((byte)word >= 0 && (byte)word < NUMBEROFWORDS) //Language is not checked for propper range because its integrity protected by a setter function
            {
                return dictionary[(byte)word,(byte)Language];
            }
            Debug.WriteLine("ERROR: GetWords was passed a value {0} that was out of range(0-{1})",(byte)word,(byte)NUMBEROFWORDS);
            return "";
        }

        public string GetPreviousLanguageWord(WORDS word)
        {
            if ((byte)word >= 0 && (byte)word < NUMBEROFWORDS) //Language is not checked for propper range because its integrity protected by a setter function
            {
                return dictionary[(byte)word, (byte)PreviousLanguage];
            }
            Debug.WriteLine("ERROR: GetWords was passed a value {0} that was out of range(0-{1})", (byte)word, (byte)NUMBEROFWORDS);
            return "";
        }

        public LANGUAGES GetLanguage()
        {
            return Language;
        }

        public void SetLanguage(LANGUAGES newLanguage)
        {
            if ((byte)newLanguage >= 0 && (byte)newLanguage < NUMBEROFLANGUAGES)
            {
                PreviousLanguage = Language;
                Language = newLanguage;
            }
            Debug.WriteLine("ERROR: SetLanguag was passed a value {0} that was out of range(0-{1})",(byte)newLanguage,(byte)NUMBEROFLANGUAGES);
        }

        /*Phrases:
         * Some expressions are more complex than a direct translation. These cases will be represented by methods.
         * For example these prases may take an argument and return a string output. This string will be formmatted
         * for gramattically correct output by using the appropriate plural form for the the output language.
         */
        

        public string NumberOfLives(int lives) //In the form of "X Lives"
        {
            switch (Language)
            {
                case LANGUAGES.Chinese:
                    return lives + "个生命";//There is no plural case for this translation
                    break;
                default:
                case LANGUAGES.English:
                    if (lives != 1)
                    {
                       return lives + " Lives";
                    }
                    else
                    {
                        return lives + " Life";
                    }
                    break;
            }
        }

        public string ShotsFromPlayerX(string PlayerX, int shots)
        {
            switch (Language)
            {
                case LANGUAGES.Chinese:
                    return "打从" + PlayerX + ", " + shots.ToString() + "个打";
                    break;
                default:
                case LANGUAGES.English:
                    if (shots == 1)
                    {
                        return "Shot by " + PlayerX + ": Once";
                    }
                    else
                    {
                        return "Shot by " + PlayerX + ": " + shots.ToString() + " Times";
                    }
                    break;
            }
        }
    }
}
