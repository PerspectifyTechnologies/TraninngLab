module.exports = {
  purge: ["./src/*/.{js,jsx,ts,tsx}", "./public/index.html"],
  darkMode: false, // or 'media' or 'class'

  theme: {
    fontSize:{
      landingp:'2vw',
      landingh:'10vw'
    },
    padding:{
      mybottom:"10px"
    },
    extend: {
      colors: {
        landingh1:'#f7fbfc',
        customblack: "#02111B",
        custombg: "#FFFFFF",
        custombrown: "#3F4045",
        customnewblue: "#fcbf49",
        customhoverblue: "#02111B",
        customwhite: "#FFFFFF",
        customgray: "#eeeeee",
        coffee: "#30292F",
        metal: "#e6ccb2",
        charcoal: "#474E57",
        customblue: "#5D737E",
        sand: "#ADB8BD",
        customwhite: "#FCFCFC",
        jet: "#3C3C43",
        log: "#023e8a",
        loghover: "#4361ee",
        customred: "#dd1c1a",
        custompink: "#fec89a",
        customdarkblue: "#222831",
        onhover: "#b7b7a4",
        onhovertext: "#3a0ca3",
        carditem: "#d7e3fc"
      },
      fontFamily: {
        myfonts: [
          "Trebuchet MS",
          "Lucida Sans Unicode",
          "Lucida Grande",
          "Lucida Sans",
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
