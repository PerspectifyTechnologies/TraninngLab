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
      eveHeight:'100vh',
      flexHeight:'70vh'
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
        imgColor: "#d8e3e7",
        perColor: "#f7fbfc",
        labColor:'yellow'
      },
    },
  },
  variants: {
    extend: {},
  },
  plugins: [],
};
