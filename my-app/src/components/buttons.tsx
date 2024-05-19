import React from 'react';
import { Text, StyleSheet, Pressable, StyleProp, ViewStyle, TextStyle } from 'react-native';

interface Props {
    onPress : ()=> void
    title: string,
    textStyle?: StyleProp<TextStyle>,
    containerStyle?: StyleProp<ViewStyle>
}

export default function Button(props:Props) {
  const { onPress, title = 'Save', textStyle, containerStyle } = props;
  return (
    <Pressable style={[styles.button, containerStyle]} onPress={onPress}>
      <Text style={[styles.text, textStyle]}>{title}</Text>
    </Pressable>
  );
}

const styles = StyleSheet.create({
  button: {
    alignItems: 'center',
    justifyContent: 'center',
    paddingVertical: 12,
    paddingHorizontal: 32,
    borderRadius: 4,
    elevation: 3,
    backgroundColor: 'black',
  },
  text: {
    fontSize: 16,
    lineHeight: 21,
    fontWeight: 'bold',
    letterSpacing: 0.25,
    color: 'white',
  },
});
