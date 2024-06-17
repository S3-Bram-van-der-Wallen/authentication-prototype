<script>
  import { goto } from '$app/navigation';
  import { signInWithEmailAndPassword } from 'firebase/auth';
  import { firebaseAuth } from '$lib/firebase';
  import { authUser } from '$lib/authStore';

  let email;
  let password;

  const login = async () => {
    try {
      const userCredential = await signInWithEmailAndPassword(firebaseAuth, email, password);
      const user = userCredential.user;
      const token = await user.getIdToken();

      $authUser = {
        uid: user.uid,
        email: user.email || ''
      };

      $authUser = token; // Store the token in the store

      console.log(userCredential);
      goto('/protected');
    } catch (error) {
      console.error(error.code, error.message);
    }
  };
</script>

<form
  class="flex flex-col gap-4 p-8 space-y-4 bg-white sm:w-10/12"
  on:submit|preventDefault={login}
>
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

  <button type="submit" class="default-action">Login</button>
</form>