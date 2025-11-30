class Reactor
  def self.criticality_balanced?(temperature, neutrons_emitted)
    if temperature >= 800000
      false
    elsif neutrons_emitted <= 500
      false
    elsif temperature * neutrons_emitted >= 500000
      false
    else
      true
    end
  end

  def self.reactor_efficiency(voltage, current, theoretical_max_power)
    generated_power = voltage * current
    efficiency = (generated_power / theoretical_max_power) * 100

    if efficiency < 30
      "black"
    elsif efficiency < 60
      "red"
    elsif efficiency < 80
      "orange"
    else
      "green"
    end
  end

  def self.fail_safe(temperature, neutrons_produced_per_second, threshold)
    criticality = temperature * neutrons_produced_per_second

    if criticality < (threshold * 0.9)
      "LOW"
    elsif criticality < (threshold * 0.1) || criticality < (threshold * 1.1)
      "NORMAL"
    else
      "DANGER"
    end
  end
end
