document.addEventListener('DOMContentLoaded', function () {
    fetchDashboardData();
    fetchRecentOrders();
});

async function fetchDashboardData() {
    try {
        const response = await fetch('/api/admin/dashboard-stats'); // Този API ендпойнт трябва да се създаде
        if (!response.ok) {
            throw new Error('Failed to fetch dashboard stats');
        }
        const data = await response.json();

        document.getElementById('total-orders').textContent = data.totalOrders;
        document.getElementById('total-users').textContent = data.totalUsers;
        document.getElementById('total-products').textContent = data.totalProducts;
        document.getElementById('total-revenue').textContent = data.totalRevenue.toFixed(2) + ' BGN';

    } catch (error) {
        console.error("Error fetching dashboard stats:", error);
    }
}

async function fetchRecentOrders() {
    try {
        const response = await fetch('/api/admin/recent-orders'); // Този API ендпойнт също трябва да се създаде
        if (!response.ok) {
            throw new Error('Failed to fetch recent orders');
        }
        const orders = await response.json();
        const tableBody = document.getElementById('recent-orders-table').querySelector('tbody');
        tableBody.innerHTML = ''; // Изчистваме старите данни

        orders.forEach(order => {
            const row = `
                <tr>
                    <td>${order.orderId}</td>
                    <td>${order.userEmail}</td>
                    <td>${order.totalAmount.toFixed(2)} BGN</td>
                    <td>${order.status}</td>
                    <td>${new Date(order.orderDate).toLocaleDateString()}</td>
                    <td>
                        <a href="/Admin/Orders/Details/${order.orderId}" class="btn btn-info btn-sm">Details</a>
                    </td>
                </tr>
            `;
            tableBody.innerHTML += row;
        });

    } catch (error) {
        console.error("Error fetching recent orders:", error);
    }
}