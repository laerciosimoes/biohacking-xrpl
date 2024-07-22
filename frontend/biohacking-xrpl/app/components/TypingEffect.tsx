'use client';

import { useEffect, useState } from 'react';

interface TypingEffectProps {
  text: string;
  speed?: number; // Velocidade do efeito de digitação em milissegundos
}

const TypingEffect: React.FC<TypingEffectProps> = ({ text, speed = 100 }) => {
  const [displayedText, setDisplayedText] = useState('');
  const [index, setIndex] = useState(0);

  useEffect(() => {
    if (index < text.length) {
      const timer = setTimeout(() => {
        setDisplayedText((prev) => prev + text[index]);
        setIndex(index + 1);
      }, speed);
      return () => clearTimeout(timer);
    }
  }, [index, text, speed]);

  return <span>{displayedText}</span>;
};

export default TypingEffect;
