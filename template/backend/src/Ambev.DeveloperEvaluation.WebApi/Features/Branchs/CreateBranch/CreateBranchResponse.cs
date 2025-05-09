namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.CreateBranch
{
    /// <summary>
    /// API response model for CreateBranch operation
    /// </summary>
    public class CreateBranchResponse
    {
        /// <summary>
        /// The unique identifier of the created branch
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// The branch name.
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the branch cnpj.
        /// </summary>
        public string Cnpj { get; set; } = string.Empty;
        /// <summary>
        /// indicates if it is parent branch.
        /// </summary>
        public bool IsParent { get; set; }
    }
}
