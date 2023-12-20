import { useSpring, animated } from "react-spring";

function AnimatedBackground() {
  const fadingBackground = useSpring({
    from: { backgroundColor: "lightblue" },
    to: { backgroundColor: "lightcoral" },
    config: { duration: 3000 },
    loop: { reverse: true },
  });

  return (
    <animated.div
      style={{
        ...fadingBackground,
        backgroundImage: "url(particles.jpg)",
        width: "100%",
        height: "100vh",
        position: "fixed",
        top: 0,
        left: 0,
        zIndex: -1,
      }}
    ></animated.div>
  );
}

export default AnimatedBackground;
