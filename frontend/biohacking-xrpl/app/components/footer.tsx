import Link from 'next/link';
import Image from 'next/image';

export default function Footer() {
  return (
    <footer className="fixed bottom-0 w-full bg-gradient-to-b from-purple-500 to-black text-neutral-content font-aldrich">
      <div className="hidden md:flex p-10">
        <nav className="flex-1">
          <h6 className="footer-title">Services</h6>
          <Link href="https://biohacking.ai" className="link link-hover">Biohacking.ai</Link>
        </nav>
        <nav className="flex-1">
          <h6 className="footer-title">Company</h6>
          <Link href="/about" className="link link-hover">About us</Link>
        </nav>
        <nav className="flex-1">
          <h6 className="footer-title">Legal</h6>
          <Link href="/terms" className="link link-hover">Terms of use</Link>
        </nav>
        <nav className="flex-1">
          <h6 className="footer-title">Social</h6>
          <div className="grid grid-flow-col gap-4">
            <a href="https://www.instagram.com/biohacking.ai/" target="_blank" rel="noopener noreferrer">
              <Image src="/instagram.png" alt="Instagram" width={24} height={24} className="shrink-0 w-8 aspect-square" />
            </a>
            <a href="https://www.linkedin.com/company/biohacking-ai-app" target="_blank" rel="noopener noreferrer">
              <Image src="/linkedin.png" alt="LinkedIn" width={24} height={24} className="shrink-0 aspect-square w-[33px]" />
            </a>
            <a href="https://twitter.com" target="_blank" rel="noopener noreferrer">
              <Image src="/twitter.png" alt="Twitter" width={24} height={24} className="shrink-0 mt-1 aspect-square w-[30px]" />
            </a>
            <a href="https://www.facebook.com/biohackingai/" target="_blank" rel="noopener noreferrer">
              <Image src="/facebook.png" alt="Facebook" width={24} height={24} className="shrink-0 aspect-square w-[34px]" />
            </a>
          </div>
        </nav>
      </div>

      {/* Footer for smaller screens */}
      <div className="md:hidden p-4 flex flex-col bg-gradient-to-b from-purple-500 to-black text-neutral-content font-aldrich items-center">
        <nav className="flex flex-col items-center">
          <Link href="/branding" className="link link-hover">Biohacking.ai</Link>
          <Link href="/about" className="link link-hover">About us</Link>
          <Link href="/terms" className="link link-hover">Terms of use</Link>
        </nav>
        <div className="flex gap-4 mt-4">
          <a href="https://www.instagram.com/biohacking.ai/" target="_blank" rel="noopener noreferrer">
            <Image src="/instagram.png" alt="Instagram" width={24} height={24} />
          </a>
          <a href="https://www.linkedin.com/company/biohacking-ai-app" target="_blank" rel="noopener noreferrer">
            <Image src="/linkedin.png" alt="LinkedIn" width={24} height={24} />
          </a>
          <a href="https://twitter.com" target="_blank" rel="noopener noreferrer">
            <Image src="/twitter.png" alt="Twitter" width={24} height={24} />
          </a>
          <a href="https://www.facebook.com/biohackingai/" target="_blank" rel="noopener noreferrer">
            <Image src="/facebook.png" alt="Facebook" width={24} height={24} />
          </a>
        </div>
      </div>
    </footer>
  );
}
