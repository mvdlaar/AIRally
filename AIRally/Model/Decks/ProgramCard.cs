namespace AIRally.Model.Decks
{
    public class ProgramCard
    {
        public ProgramCardAction CardAction { get; }

        public int Priority { get; }

        public bool Blocked { get; set; }

        internal ProgramCard(ProgramCardAction pca, int prio)
        {
            CardAction = pca;
            Priority = prio;
        }
    }
}