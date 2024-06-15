<script>
  import { goto } from '$app/navigation';

  import { createUserWithEmailAndPassword } from 'firebase/auth';
  import { firebaseAuth } from '$lib/firebase';

  let email;
  let password;

  let success = undefined;

  const register = () => {
    createUserWithEmailAndPassword(firebaseAuth, email, password)
      .then((userCredentials) => {
        console.log(userCredentials);
  
        goto('/login');
      })
      .catch((error) => {
        const errorCode = error.code;
        const errorMessage = error.message;
        console.log(errorCode, errorMessage);

        success = false;
      });
  };
</script>
  
<form
  class="flex flex-col gap-4 p-8 space-y-4 bg-white sm:w-10/12"
  on:submit|preventDefault={register}>
  {#if !success && success !== undefined}
    <div class="p-8 text-red-500 bg-red-100">There was an error registering. Please try again.</div>
  {/if}
  <input
    type="email"
    placeholder="Email"
    class="px-4 py-2 border border-gray-300 rounded-md"
    required
    bind:value={email}
  />
  <input
    type="password"
    placeholder="Password"
    class="px-4 py-2 border border-gray-300 rounded-md"
    required
    bind:value={password}
  />

  <button type="submit" class="default-action">Register</button>
</form>
