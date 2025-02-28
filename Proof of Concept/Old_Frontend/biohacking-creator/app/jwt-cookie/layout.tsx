"use client";
import { ThirdwebProvider } from "thirdweb/react";

export default function ThirdwebProviderLayout({
    children,
}: {
    children: React.ReactNode;
}) {
    return <ThirdwebProvider>{children}</ThirdwebProvider>;
}