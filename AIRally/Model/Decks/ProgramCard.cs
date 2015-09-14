using System;

namespace AIRally.Model.Decks
{
    public class ProgramCard
    {
        internal ProgramCard(ProgramCardAction pca, int prio)
        {
            CardAction = pca;
            Priority = prio;
        }

        internal static ProgramCard Get(string programCardString)
        {
            ProgramCardAction pca = ProgramCardActionUtil.Get(programCardString[0]);
            var prio = Convert.ToInt32(programCardString.Substring(1));
            return new ProgramCard(pca, prio);
        }

        public bool Blocked { get; set; }
        public ProgramCardAction CardAction { get; }
        public int Priority { get; }

        public override string ToString()
        {
            return ProgramCardActionUtil.ToChar(CardAction) + Priority.ToString();
        }
    }
}