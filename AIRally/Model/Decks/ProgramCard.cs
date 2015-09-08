namespace AIRally.Model.Decks
{
    public class ProgramCard
    {
        internal ProgramCard(ProgramCardAction pca, int prio)
        {
            CardAction = pca;
            Priority = prio;
        }

        public bool Blocked { get; set; }
        public ProgramCardAction CardAction { get; }
        public int Priority { get; }
    }
}