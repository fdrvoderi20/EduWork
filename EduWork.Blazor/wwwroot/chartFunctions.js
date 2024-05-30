function createProjectPieChart() {
    const projectData = {
        labels: [
            'Project Name 1',
            'Project Name 2',
            'Project Name 3',
            'Project Name 4'
        ],
        datasets: [{
            data: [10, 20, 30, 40], 
            backgroundColor: [
                'rgba(255, 99, 132, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(255, 206, 86, 0.2)',
                'rgba(75, 192, 192, 0.2)'
            ],
            borderColor: [
                'rgba(255, 99, 132, 1)',
                'rgba(54, 162, 235, 1)',
                'rgba(255, 206, 86, 1)',
                'rgba(75, 192, 192, 1)'
            ],
            borderWidth: 1
        }]
    };

    const config = {
        type: 'pie',
        data: projectData,
        options: {
            responsive: true,
            plugins: {
                legend: {
                    position: 'top',
                },
                title: {
                    display: true,
                    text: 'Project Distribution'
                }
            }
        },
    };

    var ctx = document.getElementById('projectPieChart').getContext('2d');
    new Chart(ctx, config);
}
