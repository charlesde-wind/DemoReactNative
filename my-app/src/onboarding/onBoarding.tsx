import Button from "@/components/buttons";
import { BRAND_NAME, BRAND_TAG_LINE } from "@/constants/nameConstants";
import { LinearGradient } from "expo-linear-gradient";
import { FC, useEffect, useRef, useState } from "react";
import {
  View,
  Text,
  StyleSheet,
  Dimensions,
  NativeSyntheticEvent,
  NativeScrollEvent,
} from "react-native";
import { ScrollView } from "react-native-gesture-handler";
import onBoardingPages from "./pages";
import OnBoardingFooter from "./onBoardingFooter";
import { mainColour } from "@/constants/colourConstants";

interface Props {}

const screenWidth = Dimensions.get("screen").width;

const Onboarding: FC<Props> = () => {
  const [currentPageIndex, setCurrentPageIndex] = useState(0);
  const scrollViewRef = useRef<ScrollView>(null);

  const changePage = (event: NativeSyntheticEvent<NativeScrollEvent>) => {
    const index = Math.round(event.nativeEvent.contentOffset.x / screenWidth);

    if (index !== currentPageIndex) {
      console.log(index);
      setCurrentPageIndex(index);
    }
  };

  const isNotOnLastPage = currentPageIndex !== onBoardingPages.length - 1;

  return (
    <LinearGradient
      start={{ x: 0.5, y: 0 }}
      end={{ x: 0.5, y: 2 }}
      style={styles.gradientBackground}
      colors={[mainColour.primary, mainColour.secondary, mainColour.tertiary]}
    >
      <View style={styles.heroTextContainer}>
        <Text style={styles.heroText}>{BRAND_NAME}</Text>
        <Text style={styles.tagText}>{BRAND_TAG_LINE}</Text>
      </View>
      <View style={styles.contentConainer}>
        <ScrollView
          ref={scrollViewRef}
          onScroll={changePage}
          horizontal
          style={styles.scrollContainer}
          pagingEnabled
          showsHorizontalScrollIndicator={false}
        >
          {onBoardingPages.map((page, index) => (
            <View
              key={page.heroText + index}
              style={{ ...styles.page, width: screenWidth }}
            >
              <Text style={styles.mainText}>{page.heroText}</Text>
              <Text style={styles.additionalText}>{page.additionalText}</Text>
            </View>
          ))}
        </ScrollView>
        <OnBoardingFooter
          isNotOnLastPage={isNotOnLastPage}
          currentPageIndex={currentPageIndex}
          onLogin={console.log}
          onCreateAccount={console.log}
        />
      </View>
    </LinearGradient>
  );
};

const styles = StyleSheet.create({
  scrollContainer: {
    display: "flex",
    flexDirection: "row",
    flex: 2,
  },
  gradientBackground: {
    flex: 1,
    backgroundColor: mainColour.tertiary,
  },
  page: {
    alignItems: "center",
    flex: 5,
    paddingLeft: 5,
  },
  contentConainer: {
    borderTopRightRadius: 50,
    borderTopLeftRadius: 50,
    backgroundColor: "white",
    flex: 2,
    justifyContent: "flex-end",
  },
  mainText: {
    marginLeft: 13,
    marginTop: 39,
    fontSize: 16,
    width: 143,
    color: "black",
    fontWeight: "700",
  },
  additionalText: {
    marginLeft: 13,
    marginTop: 39,
    fontSize: 15,
    width: 250,
    color: "black",
  },
  heroTextContainer: {
    justifyContent: "center",
    flex: 3,
    alignItems: "center",
  },
  heroText: {
    fontSize: 40,
    fontWeight: "700",
    paddingTop: 20,
    color: "white",
  },
  tagText: {
    paddingTop: 18,
    fontSize: 18,
    fontWeight: "700",
    width: 180,
    textAlign: "center",
    color: "white",
  },
});

export default Onboarding;
