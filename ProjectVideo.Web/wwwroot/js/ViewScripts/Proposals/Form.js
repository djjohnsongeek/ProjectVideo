class ProposalFormPage {
    membersInputAddBtn;
    membersComplexInputCollection;

    linksInputAddBtn;
    linksComplexInputCollection;

    roleNameDatalistId = "rolename-options";
    membersInputContainerId = "members-input-container";
    videoLinksInputContainerId = "links-input-container";
    linksInputContainerId = "";

    constructor() {
        this.membersInputAddBtn = document.getElementById("members-input-add-btn");
        this.linksInputAddBtn = document.getElementById("links-input-add-btn");

        // Members inputs
        this.membersComplexInputCollection = new ComplexInputCollection(this.membersInputContainerId);
        this.membersComplexInputCollection.addInputGroup(this.buildDefaultMemberInputGroup());
        this.membersInputAddBtn.addEventListener("click", (event) => {
            this.membersComplexInputCollection.addInputGroup(this.buildDefaultMemberInputGroup());
        });

        // Video Links inputs
        this.videoLinkComplexInputCollection = new ComplexInputCollection(this.videoLinksInputContainerId);
        this.videoLinkComplexInputCollection.addInputGroup(this.buildDefaultLinkInputGroup());
        this.linksInputAddBtn.addEventListener("click", (event) => {
            this.videoLinkComplexInputCollection.addInputGroup(this.buildDefaultLinkInputGroup());
        });
    }

    buildDefaultMemberInputGroup() {
        const inputGroup = new ComplexObjectInputGroup("TeamMembers", crypto.randomUUID());
        const complexInputs = [
            new ComplexInput("Name", "Name", crypto.randomUUID(), ""),
            new ComplexInput("Role", "Role", crypto.randomUUID(), "", this.roleNameDatalistId)
        ]
        for (let input of complexInputs) {
            inputGroup.addInput(input);
        }

        return inputGroup;
    }

    buildDefaultLinkInputGroup() {
        const inputGroup = new ComplexObjectInputGroup("VideoLinks", crypto.randomUUID());
        const complexInputs = [
            new ComplexInput("Name", "Name", crypto.randomUUID(), ""),
            new ComplexInput("Url", "Url", crypto.randomUUID(), "")
        ]
        for (let input of complexInputs) {
            inputGroup.addInput(input);
        }

        return inputGroup;
    }
}

var proposalForm = new ProposalFormPage();