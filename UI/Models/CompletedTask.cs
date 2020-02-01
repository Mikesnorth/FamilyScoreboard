using System;

namespace UI.Models {
    public class CompletedTask {
        public int Id { get; set; }
        public FamilyMember FamilyMember { get; set; }
        public Task Task { get; set; }
        public int PointsEarned { get; set; }
        public DateTimeOffset DateEarned { get; set; }
    }
}
