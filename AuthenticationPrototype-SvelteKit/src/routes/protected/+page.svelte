<script lang="ts">
  import { authUser } from '$lib/authStore';
  import { redirect } from '@sveltejs/kit';

  export const load = async ({ fetch }) => {
    let token;

    const unsubscribe = authUser.subscribe((user) => {
      if (user) {
        token = user.token; // Assuming your AuthUser interface has a 'token' property
        console.log("there is a token");
      }
      console.log("there is no token");
    });

    unsubscribe();

    if (!token) {
      throw redirect(302, '/login');
    }

    try {
      const response = await fetch('/protected', {
        headers: {
          'Authorization': `Bearer ${token}`
        }
      });

      if (!response.ok) {
        throw new Error('Failed to fetch data');
      }

      const result = await response.json();
      return { data: result.data };
    } catch (error) {
      console.error('Error fetching data:', error);
      throw error; // Rethrow the error to be caught by the error boundary
    }
  };

  export let data;
  console.log("the data:");
  console.log(data);
</script>

<svelte:head>
  <title>Protected route</title>
</svelte:head>

<h1 class="text-4xl font-bold">Protected route</h1>
<p>{data}</p>
