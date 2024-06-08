using Domain.Enums;

namespace Domain.ValueObjects
{
    public record NoteArrangementStatus
    {
        public NoteArrangement Arrangement { get; private set; }

        public NoteArrangementStatus(NoteArrangement arrangement)
        {
            Arrangement = arrangement;
        }

        public string GetName()
        {
            return Arrangement switch
            {
                NoteArrangement.Normal => "Normal",
                NoteArrangement.Random => "Random",
                NoteArrangement.RRandom => "R-Random",
                NoteArrangement.SRandom => "S-Random",
                NoteArrangement.Mirror => "Mirror",
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }

}
