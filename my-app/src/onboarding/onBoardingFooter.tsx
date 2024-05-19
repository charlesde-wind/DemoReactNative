import { View, StyleSheet } from "react-native";
import onBoardingPages from "./pages";
import Button from "@/components/buttons";
import { FC } from "react";
import { MaybePromise } from "@/utils/types";
import { greyColour, mainColour } from "@/constants/colourConstants";

interface Props {
  isNotOnLastPage: boolean;
  currentPageIndex: number;
  onLogin: () => MaybePromise<void>;
  onCreateAccount: () => MaybePromise<void>;
}

const CREATE_ACCOUNT = "Create Acoount";
const LOGIN = "Login";

const OnBoardingFooter: FC<Props> = ({
  isNotOnLastPage,
  currentPageIndex,
  onCreateAccount,
  onLogin,
}) => (
  <View style={styles.dotContainer}>
    {isNotOnLastPage ? (
      onBoardingPages.map((page, index) => (
        <View
          key={page.heroText + index}
          style={
            index === currentPageIndex
              ? styles.activatedPaginatedDot
              : styles.deactivatedPaginatedDot
          }
        ></View>
      ))
    ) : (
      <View style={styles.btnContainer}>
        <Button
          onPress={onCreateAccount}
          title={CREATE_ACCOUNT}
          containerStyle={{ ...styles.btn, ...styles.btnCreateAcc }}
        ></Button>
        <Button
          onPress={onLogin}
          title={LOGIN}
          containerStyle={{ ...styles.btn, ...styles.btnLogin }}
        ></Button>
      </View>
    )}
  </View>
);

const styles = StyleSheet.create({
  btnContainer: {
    display: "flex",
    flexDirection: "column",
    flex: 1,
    gap: 10,
    alignItems: "center",
    justifyContent: "flex-start",
  },
  btn: {
    width: 190,
  },
  btnCreateAcc: {
    backgroundColor: mainColour.tertiary,
  },
  btnLogin: {
    backgroundColor: "#3089BC",
  },
  activatedPaginatedDot: {
    width: 12,
    height: 12,
    borderRadius: 50,
    backgroundColor: mainColour.tertiary,
  },
  deactivatedPaginatedDot: {
    width: 8,
    height: 8,
    borderRadius: 50,
    backgroundColor: greyColour,
  },
  dotContainer: {
    flexDirection: "row",
    gap: 5,
    flex: 1,
    justifyContent: "center",
    alignItems: "center",
  },
});

export default OnBoardingFooter;
