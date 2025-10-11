namespace api.Glossaries
{
    public class GlossaryMapper
    {

        public static string GenerateGlossaryCode(Guid glossaryId)
        {
            string shortGuid = glossaryId.ToString("N").Substring(0, 5).ToUpper();
            return $"GL-{shortGuid}";
        }
    }
}
