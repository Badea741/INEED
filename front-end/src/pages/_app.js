import { ChakraProvider } from "@chakra-ui/react";
import Footer from "../components/Footer";
import NavigationBar from "../components/NavigationBar";

function MyApp({ Component, pageProps }) {
  return (
    <ChakraProvider>
      <NavigationBar />
      <Component {...pageProps} />
      <Footer />
    </ChakraProvider>
  );
}

export default MyApp;
