<template>
  <div class="home-container">
    <h1 class="title">
      Welcome to the <em>unofficial </em>
      <span class="valorant-font">VALORANT</span> Franchising Player Database!
    </h1>
    <p class="subtitle">
      Select which region you would like to comb through below!
    </p>

    <div class="region-icons">
      <router-link to="/region/americas" class="region">
        <img
          src="/src/assets/vct-americas-png.png"
          alt="Americas"
          class="region-icon"
        />
        <p class="region-label">AMERICAS</p>
      </router-link>
      <router-link to="/region/emea" class="region">
        <img
          src="/src/assets/vct-emea-png.png"
          alt="EMEA"
          class="region-icon"
        />
        <p class="region-label">EMEA</p>
      </router-link>
      <router-link to="/region/china" class="region">
        <img
          src="/src/assets/vct-china-png.png"
          alt="China"
          class="region-icon"
        />
        <p class="region-label">CHINA</p>
      </router-link>
      <router-link to="/region/pacific" class="region">
        <img
          src="/src/assets/vct-pacific-png.png"
          alt="Pacific"
          class="region-icon"
        />
        <p class="region-label">PACIFIC</p>
      </router-link>
    </div>
  </div>
</template>

<script>
export default {
  name: "Home",
  data() {
    return {
      regions: [
        {
          name: "AMERICAS",
          image: "src/assets/vct-americas-png.png",
          route: "/americas",
        },
        { name: "EMEA", image: "src/assets/vct-emea-png.png", route: "/emea" },
        {
          name: "CHINA",
          image: "src/assets/vct-china-png.png",
          route: "/china",
        },
        {
          name: "PACIFIC",
          image: "src/assets/vct-pacific-png.png",
          route: "/pacific",
        },
      ],
    };
  },
  methods: {
    navigateToRegion(route) {
      this.$router.push(route);
    },
  },
};
</script>

<style scoped>
/* Import the Valorant font */
@font-face {
  font-family: "ValorantFont";
  src: url("/Valorant Font.ttf") format("truetype");
  font-weight: normal;
  font-style: normal;
}

/* Container styling */
.home-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  text-align: center;
  padding: 2rem;
  font-family: "Arial", sans-serif;
  color: #f4f4f4;
  min-height: 100vh;
}

/* Title styling */
.title {
  font-size: 2.5rem;
  margin-bottom: 1rem;
  font-weight: bold;
  color: #ff4655; /* Valorant red */
}

.title em {
  font-style: italic;
  color: #ffb800; /* Gold for emphasis */
}

/* Apply Valorant font specifically to the word VALORANT */
.valorant-font {
  font-family: "ValorantFont", sans-serif;
  font-size: 2.5rem;
  margin-bottom: 1rem;
  font-weight: bold;
  color: #ff4655; /* Valorant red */
}

/* Subtitle styling */
.subtitle {
  font-size: 1.2rem;
  margin-bottom: 2rem;
  color: #e0e0e0; /* Lighter gray for subtitle */
}

/* Region icons container */
.region-icons {
  display: flex;
  justify-content: center;
  flex-wrap: wrap;
  gap: 2rem;
}

/* Individual region styling */
.region {
  display: flex;
  flex-direction: column;
  align-items: center;
  cursor: pointer;
  transition: transform 0.3s ease, box-shadow 0.3s ease;
}

.region:hover {
  transform: scale(1.1);
  box-shadow: 0 8px 20px rgba(0, 0, 0, 0.5);
}

/* Region icon styling */
.region-icon {
  width: 100px;
  height: 100px;
  border-radius: 50%;
  background-color: #2c2c3c; /* Placeholder color for missing images */
  display: flex;
  align-items: center;
  justify-content: center;
}

/* Region label styling */
.region-label {
  margin-top: 0.5rem;
  font-size: 1rem;
  color: #ffffff;
  font-weight: bold;
  font-family: "ValorantFont", sans-serif;
}
</style>
