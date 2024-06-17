import { json } from '@sveltejs/kit';

export async function GET({ request }) {
    const authHeader = request.headers.get('Authorization');
    
    const response = await fetch('https://localhost:7066/test', {
        headers: {
            'Authorization': authHeader
        }
    });

    if (response.ok) {
        const data = await response.json();
        return json({ data });
    } else {
        return json({
            status: response.status,
            statusText: response.statusText
        }, { status: response.status });
    }
}
