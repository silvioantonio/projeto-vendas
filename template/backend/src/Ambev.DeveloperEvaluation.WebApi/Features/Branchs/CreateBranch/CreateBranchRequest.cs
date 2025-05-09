namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.CreateBranch
{
    /// <summary>
    /// Represents a request to create a new branch in the system.
    /// </summary>
    public class CreateBranchRequest
    {
        /// <summary>
        /// Gets or sets the branch name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the branch cnpj.
        /// </summary>
        public string Cnpj { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets if it is parent branch.
        /// </summary>
        public bool IsParent { get; set; }
    }
}
