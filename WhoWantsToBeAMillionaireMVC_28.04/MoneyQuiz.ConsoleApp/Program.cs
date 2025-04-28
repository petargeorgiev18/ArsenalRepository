using MoneyQuiz.Core;
using MoneyQuiz.Data.Data;
using MoneyQuiz.Data.Data.Models;

namespace MoneyQuiz.ConsoleApp
{
    public class Program
    {
        public static MoneyQuizContext context = new MoneyQuizContext();
        public static MoneyQuizController moneyQuizController = new MoneyQuizController(context);
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Добре дошли в приложението MoneyQuiz ===");
            Console.WriteLine("Изберете една от следните опции:");
            while (true)
            {
                Console.WriteLine("1. Добавяне на въпрос");
                Console.WriteLine("2. Добавяне на точно 4 отговора за избран въпрос");
                Console.WriteLine("3. Редактиране на въпрос по посочено id");
                Console.WriteLine("4. Редактиране на отговор по посочено id");
                Console.WriteLine("5. Изтриване на жокер");
                Console.WriteLine("6. Добавяне на участник");
                Console.WriteLine("7. Извеждане текста на въпросите за сума по-голяма от 3000 лв.");
                Console.WriteLine("8. Изведете текста на въпросите и всичките възможни отговори за всеки въпрос");
                Console.WriteLine("9. Извеждане текста на въпроса и на верния отговор само за въпросите за посочена сума.");
                Console.WriteLine("10. Изход");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Въведете текста на въпроса: ");
                        string questionText = Console.ReadLine();
                        Console.WriteLine("Въведете сумата на въпроса: ");
                        string amountText = Console.ReadLine();
                        Question question = new Question
                        {
                            Question_Text = questionText,
                            Amount = int.Parse(amountText)
                        };
                        await moneyQuizController.AddQuestion(question);
                        Console.WriteLine("Въпроса е добавен успешно.");
                        break;
                    case "2":
                        Console.Write("Въведете id на въпроса, за който искате да добавите отговори: ");
                        int questionId = int.Parse(Console.ReadLine());
                        Question question1 = context.Questions.FirstOrDefault(q => q.Id == questionId);
                        if (question1 != null)
                        {
                            Console.WriteLine("Въведете 4 отговора за въпроса:");
                            List<Answer> answers = new List<Answer>();
                            for (int i = 1; i <= 4; i++)
                            {
                                Console.Write($"Отговор {i}: ");
                                string answerText = Console.ReadLine();                                                          
                                Answer answer = new Answer
                                {
                                    Answer_Text = answerText,
                                    Question_Id = questionId
                                };
                                Console.WriteLine("Верен ли е?");
                                Console.WriteLine("1. Да");
                                Console.WriteLine("2. Не");
                                int isCorrectInput = int.Parse(Console.ReadLine());
                                if (isCorrectInput == 1)
                                {
                                    answer.Is_Correct = true;
                                }
                                else if (isCorrectInput == 2)
                                {
                                    answer.Is_Correct = false;
                                }
                                answers.Add(answer);
                            }
                            await moneyQuizController.AddAnswersToQuestion(question1, answers);
                            Console.WriteLine("Отговорите са добавени успешно.");
                        }
                        else
                        {
                            Console.WriteLine("Въпросът с посоченото id не съществува.");
                        }
                        break;
                    case "3":
                        Console.Write("Въведете id на въпроса, който искате да бъде редактиран: ");
                        int editQuestionId = int.Parse(Console.ReadLine());
                        Question? editQuestion = context.Questions.FirstOrDefault(q => q.Id == editQuestionId);
                        if(editQuestion != null)
                        {
                            Console.Write("Въведете новия текст на въпроса: ");
                            string newQuestionText = Console.ReadLine()!;
                            moneyQuizController.EditQuestionById(editQuestionId, newQuestionText);
                            Console.WriteLine("Въпросът е редактиран успешно.");
                        }
                        else
                        {
                            Console.WriteLine("Въпросът с посоченото id не съществува.");
                        }
                        break;
                    case "4":
                        Console.Write("Въведете id на отговора, който искате да бъде редактиран: ");
                        int editAnswerId = int.Parse(Console.ReadLine());
                        Answer? editAnswer = context.Answers.FirstOrDefault(a => a.Id == editAnswerId);
                        if (editAnswer != null)
                        {
                            Console.Write("Въведете новия текст на отговора: ");
                            string newAnswerText = Console.ReadLine()!;
                            Console.WriteLine("Верен ли е?");
                            bool isCorrect = bool.Parse(Console.ReadLine());
                            await moneyQuizController.EditAnswerById(editAnswerId, newAnswerText, isCorrect);
                            Console.WriteLine("Отговорът е редактиран успешно.");
                        }
                        else
                        {
                            Console.WriteLine("Отговорът с посоченото id не съществува.");
                        }
                        break;
                    case "5":
                        Console.Write("Въведете id на жокера, който искате да бъде изтрит: ");
                        int deleteLifelineId = int.Parse(Console.ReadLine());
                        Lifeline? deleteLifeline = context.Lifelines.FirstOrDefault(l => l.Id == deleteLifelineId);
                        if (deleteLifeline != null)
                        {
                            await moneyQuizController.DeleteLifelineById(deleteLifelineId);
                            Console.WriteLine("Жокерът е изтрит успешно.");
                        }
                        else
                        {
                            Console.WriteLine("Жокерът с посоченото id не съществува.");
                        }
                        break;
                    case "6":
                        Console.Write("Въведете името на участника: ");
                        string playerName = Console.ReadLine();
                        Console.Write("Въведете имейл на участника: ");
                        string playerEmail = Console.ReadLine();
                        Player player = new Player
                        {
                            Name = playerName,
                            Email = playerEmail
                        };
                        await moneyQuizController.AddPlayer(player);
                        Console.WriteLine("Участникът е добавен успешно.");
                        break;
                    case "7":
                        Console.WriteLine(await moneyQuizController.GetTextOfAllQuestionsWithAmountMoreThan3000());
                        break;
                    case "8":
                        Console.WriteLine(await moneyQuizController.GetQuestionTextsAndAnswersForEachQuestion());
                        break;
                    case "9":
                        Console.Write("Въведете сума: ");
                        int amount = int.Parse(Console.ReadLine());
                        Console.WriteLine(await moneyQuizController.GetQuestionTextAndAnswerByAmount(amount));
                        break;
                    case "10":
                        Console.WriteLine("Изход от приложението.");
                        return;
                    default:
                        Console.WriteLine("Невалиден избор, опитайте отново.");
                        continue;
                }
            }
        }
    }
}
