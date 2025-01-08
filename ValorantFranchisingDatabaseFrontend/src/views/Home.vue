<template>
  <div class="home-container">
    <h1 class="title">
      Welcome to the <em>unofficial </em>
      <span class="valorant-font">VALORANT</span> Franchising Player Database!
    </h1>
    <p class="subtitle">
      This database compiles information about franchised players, teams, and
      their matches across all VALORANT regions. Dive in to explore team
      rosters, match histories, and more.
    </p>
    <p class="description">
      Select a region below to start exploring! Each region showcases its teams
      and players, offering detailed insights into the VALORANT competitive
      scene.
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
    <p class="smaller-description">
      note: all data is received from vlr.gg and is not associated with vlr.gg
      nor VALORANT. all of the teams' info were received from each region's
      respective 2025 KICKOFF tournament. if you encounter any bugs, contact the
      developer at
      <a
        href="https://angel-heredia.com/"
        target="_blank"
        rel="noopener noreferrer"
      >
        his website</a
      >.
    </p>
  </div>
</template>

<script>
export default {
  name: "Home",
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
  font-size: 3rem;
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
  font-size: 3.5rem;
  font-weight: bold;
  color: #ff4655; /* Valorant red */
}

/* Subtitle styling */
.subtitle {
  font-size: 1.5rem;
  margin-bottom: 1rem;
  color: #e0e0e0; /* Lighter gray for subtitle */
}

/* Description styling */
.description {
  font-size: 1.2rem;
  margin-bottom: 2rem;
  color: #cccccc; /* Slightly muted text */
  max-width: 600px;
  line-height: 1.6;
}

.smaller-description {
  font-size: 0.9rem;
  margin-bottom: 2rem;
  color: #cccccc; /* Slightly muted text */
  max-width: 600px;
  line-height: 1.6;
}

/* Region icons container */
.region-icons {
  display: flex;
  justify-content: center;
  flex-wrap: wrap;
  gap: 2.5rem;
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
  transform: scale(1.15);
  box-shadow: 0 10px 30px rgba(0, 0, 0, 0.6);
}

/* Region icon styling */
.region-icon {
  width: 150px;
  height: 150px;
  border-radius: 50%;
  background-color: #2c2c3c; /* Placeholder color for missing images */
  display: flex;
  align-items: center;
  justify-content: center;
  box-shadow: 0 5px 15px rgba(0, 0, 0, 0.5);
  transition: transform 0.3s ease;
}

.region-icon:hover {
  transform: scale(1.1);
}

/* Region label styling */
.region-label {
  margin-top: 0.75rem;
  font-size: 1.5rem;
  color: #ffffff;
  font-weight: bold;
  font-family: "ValorantFont", sans-serif;
  text-transform: uppercase;
}
</style>
