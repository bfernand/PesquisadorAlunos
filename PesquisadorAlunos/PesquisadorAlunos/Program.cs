using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace PesquisadorAlunos
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();
            const int idInicio = 1;
            const int idFim = 1000;

            int id = idInicio;
            String url = "http://fcv.matheusacademico.com.br/Aluno/frmAlunoAlteracao.asp?id=";

            driver.Navigate().GoToUrl(url + id);
            driver.Manage().Window.Maximize();

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"c:\AllStudents1.txt", true))
            {
                while (id < idFim)
                {
                    driver.Navigate().GoToUrl(url + id);
                    IWebElement nome = driver.FindElement(By.Id("txtNome"));
                    IWebElement email = driver.FindElement(By.Id("txtmail_maior"));

                    if (nome.GetAttribute("value").ToString() != "")
                        file.WriteLine(id.ToString() + " - " + nome.GetAttribute("value").ToString() + " - " + email.GetAttribute("value").ToString());
                    id++;
                }
            }
        }
    }
}
