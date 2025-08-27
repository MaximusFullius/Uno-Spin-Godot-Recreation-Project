uno ai decision diagram pseudocode

List<UnoCards> playableCardsCPU1  = AssessPlayableCards(CPU1hand);


public void AIturn(List<UnoCards> playableCards, CPUplayer cpu, bPlayByDrawnCard){
	string wildColor;
	if (!bPlayByDrawnCard){
		if (playableCards.size() > 0){
			if (playableCards.size() == 1){
				if (cpu.GetHandSize() == 1){
					gameMaster.winGame(cpu);
				}
				else{ // Current player isn't about to win.
					if (cpu.NextPlayerHasUno()){
						if (playableCards.ContainsType("+2")){ // TODO: Implement "ContainsType" method in UnoHand class.
							cpu.PlayCardFromHand("+2", TieBreaker="colorchange")); // TODO: Impplement PlayCardFromHandc method in CPU class.
						}
						else if (playableCards.ContainsType("+4"){
							cpu.PlayCardFromHand("+4", TieBreaker="none", GetBestWildColor(cpu));
						}
						else if (playableCards.ContainsType("wild")){
							cpu.PlayCardFromHand("wild", TieBreaker="none", GetBestWildColor(cpu));
						}
						else if (!cpu.previousPlayerHasUno() && playableCards.ContainsType("reverse")){ // play reverse
							cpu.PlayCardFromHand("reverse", TieBreaker="colorchange");
						}
						else{ // draw a card and play by that
							List<UnoCards> DrawnCard = drawCard()
							AIturn(drawCard(), cpu, true);
						}
					}
					else{ // Next player doesn't have uno. Play a random card.
						cpu.PlayRandomCard(playableCards);
					}
				}
			}
			else{ // More than one playable card
				if (cpu.NextPlayerHasUno()){
					if (cpu.SecondNextPlayerHasUno){
						if (playableCards.ContainsType("spin")) { // TODO: Reimplement card types rather than just numbers.
							cpu.PlayCardTypeFromHand("spin", TieBreaker="colorchange", GetBestWildColor(cpu))) // TODO: Implement PlayCardTypeFromHand in CPU class
						}
						else{ // draw a card and play by that
							List<UnoCards> DrawnCard = drawCard()
							AIturn(drawCard(), cpu, true);
						}
					}
					else{ // 2nd next player doesn't have uno, next player does have uno.
						if (playableCards.ContainsType("+2")){
							cpu.PlayCardFromHand("+2", TieBreaker="colorchange"));
						}
						else if (playableCards.ContainsType("+4"){
							cpu.PlayCardFromHand("+4", TieBreaker="none", GetBestWildColor(cpu));
						}
						else if (playableCards.ContainsType("skip")){
							cpu.PlayCardFromHand("skip", TieBreaker = "colorchange")
						}
					}
				}
				else{ // next player doesn't have uno
					
				}
			}
		}
		else{ // No playable cards. Draw a card and play by that card.
			List<UnoCards> DrawnCard = drawCard()
			AIturn(drawCard(), cpu, true);
		}
	}
	else{ // playing by drawn card
		if (isPlayable(playableCards)){
			cpu.PlayCardFromHand(cpu, drawnCard, cpu);
		}
		else{ // drawn card isn't playable
			gameMaster.endTurn(cpu);
		}
	}
}