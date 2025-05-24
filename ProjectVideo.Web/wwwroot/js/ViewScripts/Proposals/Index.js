class ProposalIndex {
    constructor() {
        this.proposalsTable = $("#proposals-table").DataTable({
            layout: {
                topStart: 'pageLength',
                topEnd: null,
                bottomStart: 'info',
                bottomEnd: 'paging'
            }
        });

        document.getElementById("proposals-search-input").addEventListener("keyup", (event) => {
            const searchQuery = event.currentTarget.value;
            this.proposalsTable.search(searchQuery).draw();
        });
    }
}


const proposalIndex = new ProposalIndex();