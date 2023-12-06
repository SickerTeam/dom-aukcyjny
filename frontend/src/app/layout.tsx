import './globals.css'
import { Footer, Navbar } from '../../components'

export const metadata = {
  title: "Dom Aukcyjny",
  description: "Welcome to Zong",
};

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html lang="en">
      <body className="flex flex-col min-h-screen">
        <Navbar />
        {children}
        <Footer />
      </body>
    </html>
  );
}
