import Link from 'next/link';

export default function Footer() {
  return (
    <footer className="footer p-10 text-neutral-content bg-gradient-to-b from-purple-500 to-black fixed bottom-0 w-full">      <nav>
        <h6 className="footer-title">Services</h6>
        <Link href="/branding" className="link link-hover">Biohacking.ai</Link>
        <Link href="/design" className="link link-hover">Design</Link>
      </nav>
      <nav>
        <h6 className="footer-title">Company</h6>
        <Link href="/about" className="link link-hover">About us</Link>
        <Link href="/contact" className="link link-hover">Contact</Link>
      </nav>
      <nav>
        <h6 className="footer-title">Legal</h6>
        <Link href="/terms" className="link link-hover">Terms of use</Link>
        <Link href="/privacy" className="link link-hover">Privacy policy</Link>
      </nav>
    </footer>
  );
}
