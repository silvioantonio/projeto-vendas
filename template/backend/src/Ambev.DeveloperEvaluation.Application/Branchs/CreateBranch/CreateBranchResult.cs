﻿namespace Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch
{
    /// <summary>
    /// Represents the response returned after successfully creating a new branch.
    /// </summary>
    /// <remarks>
    /// This response contains the unique identifier of the newly created branch,
    /// which can be used for subsequent operations or reference.
    /// </remarks>
    public class CreateBranchResult
    {
        /// <summary>
        /// Gets or sets the unique identifier of the newly created branch.
        /// </summary>
        /// <value>A GUID that uniquely identifies the created branch in the system.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets the branch name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets the branch cnpj.
        /// </summary>
        public string Cnpj { get; set; } = string.Empty;

        /// <summary>
        /// indicates if it is parent branch.
        /// </summary>
        public bool IsParent { get; set; } = false;
    }
}
