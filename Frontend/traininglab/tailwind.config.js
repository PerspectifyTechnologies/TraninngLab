module.exports = {
  purge: ["./src/**/*.{js,jsx,ts,tsx}", "./public/index.html"],
  darkMode: false,
  theme: {
    fontSize: {
      perFont: "10vw",
      labFont: "2vw",
    },
    height: {
      imgHeight: "30vh",
      starterHeight: "110vh",
      trialHeight: "90vh",
      eveHeight: "100vh",
      flexHeight: "70vh",
    },
    borderRadius: {
      imgRadius: "10px",
    },
    padding: {
      lab: "7px",
      training: "3px",
    },
    extend: {
      colors: {
        navBackground: "#332155",
        customwhite: "#FFFFFF",
        customnewblue: "#00ADB5",
        customblack: "#02111B",
        imgColor: "#d8e3e7",
        perColor: "#f7fbfc",
        labColor: "yellow",
        customhoverblue: "#3edbf0",
        customdarkblue: "#222831",
        onhover: "#b7b7a4",
      },
      fontFamily: {
        myfonts: [
          "Trebuchet MS",
          "Lucida Sans Unicode",
          "Lucida Grande",
          "Lucida Sans",
          "Arial",
          "sans-serif",
        ],
      },
    },
  },
  variants: {
    extend: {},
  },
  plugins: [],
};
