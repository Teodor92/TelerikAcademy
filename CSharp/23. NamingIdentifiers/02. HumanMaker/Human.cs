namespace SimpleHumanCreator
{
    using System.Text;

    public class Human
    {
        public Gender Gender { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        // This is added only for testing
        public override string ToString()
        {
            StringBuilder outputText = new StringBuilder();
            outputText.AppendFormat("Gender: {0}, Name: {1}, Age: {2}", this.Gender, this.Name, this.Age);

            return outputText.ToString();
        }
    }
}