class ProposalFormPage {
    membersInputAddBtn;
    membersComplexCollectionInput;

    linksInputAddBtn;
    linksComplexCollectionInput;

    constructor() {
        this.membersInputAddBtn = document.getElementById("members-input-add-btn");
        this.linksInputAddBtn = document.getElementById("links-input-add-btn");

        this.membersComplexCollectionInput = new ComplexCollectionInput(
            "members-input-container",
            "TeamMembers",
            ["Name", "Role"],
            ["Name", "Role"]
        );

        this.linksComplexCollectionInput = new ComplexCollectionInput(
            "links-input-container",
            "VideoLinks",
            ["Name", "Url"],
            ["Link Name", "Link URL"]
        )

        this.membersInputAddBtn.addEventListener("click", (event) => {
            this.membersComplexCollectionInput.updateCount(1);
        });
        this.linksInputAddBtn.addEventListener("click", (event) => {
            this.linksComplexCollectionInput.updateCount(1);
        });

        this.linksInputContainer = document.getElementById("");

        this.membersComplexCollectionInput.renderInputs();
        this.linksComplexCollectionInput.renderInputs();
    }
}

var proposalForm = new ProposalFormPage();