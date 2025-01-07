<template>
  <div class="region-page">
    <h1>Welcome to the AMERICAS Region Page</h1>
    <p>Explore teams, players, and stats from the Americas region!</p>
  </div>
</template>

<script>
export default {
  name: "Americas",
};
</script>

<style scoped>
.region-page {
  display: flex;
  flex-direction: column;
  align-items: center;
  text-align: center;
  padding: 2rem;
  font-family: "Arial", sans-serif;
  color: #f4f4f4;
  min-height: 100vh;
}

.region-page h1 {
  font-size: 2.5rem;
  color: #ff4655; /* Valorant red */
}

.region-page p {
  font-size: 1.2rem;
  color: #e0e0e0; /* Light gray */
}
</style>
