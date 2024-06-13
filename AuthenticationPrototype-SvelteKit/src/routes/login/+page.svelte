<script lang="ts">
    let email: string;
    let password: string;
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